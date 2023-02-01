/* The Seed : SoftBody
 * by Pebloop
 * 
 * Add this script to an object to turn it into a softbody.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheSeed
{
    namespace Physic
    {

        public class SoftBody : MonoBehaviour
        {
            enum ColliderShape
            {
                Sphere,
                Cube
            }

            [SerializeField]
            [Tooltip("The shape of the colliders of each vertices.")]
            private ColliderShape _massShape = ColliderShape.Cube;

            [SerializeField]
            [Range(0, 1)]
            [Tooltip("Size of the colliders of each vertices.")]
            private float _massSize = 1;

            [SerializeField]
            [Range(0, 10)]
            [Tooltip("Maximal dispacement of the mass.")]
            private float _maxDisplacement = 0.3f;

            [SerializeField]
            [Range(0, 100)]
            [Tooltip("Set how much your object will bounce.")]
            private float _bounciness = 1;

            [SerializeField]
            [Range(0, 100)]
            [Tooltip("Set how stiff your object will be. The higher value, the bigger deformation.")]
            private float _stiffness = 5;

            [SerializeField]
            [Range(0, 100)]
            [Tooltip("Set the force received by the object on collision. If set to 0, the softbody won't react to collision, but can still be triggered manually.")]
            private float _collisionForce = 5;

            
            private Mesh _originalMesh = null; // We store the original mesh before messing with it.
            private int _verticesCount = 0;
            private SoftVertice[] _vertices = null;
            private Vector3[] _currentVertices = null;

            private class SoftVertice
            {
                public Vector3 OriginalPosition { get; private set; } = Vector3.zero;
                public Vector3 CurrentPosition { get; private set; } = Vector3.zero;
                private Vector3 _velocity = Vector3.zero;
                private GameObject _gameObject = null;
                private GameObject _gameObjectParent = null;
                private Collider _collider = null;
                private Rigidbody _rigidBody = null;
                private uint _id = 0;

                /// <summary>
                /// Get the displacement between the current position and the original position
                /// </summary>
                /// <returns>The displacement of the vertex</returns>
                public Vector3 GetDisplacement()
                {
                    return CurrentPosition - OriginalPosition;
                }

                public void Update(float stiffness)
                {
                    //CurrentPosition += _velocity * Time.deltaTime;
                    _rigidBody.AddForce(GetDisplacement() * stiffness);
                    // _rigidBody.AddForce();
                    CurrentPosition = _gameObject.transform.localPosition;
                }

                private void CreateVerticeObject(float massSize, ColliderShape massShape)
                {
                    _gameObject.transform.SetParent(_gameObjectParent.transform);
                    _gameObject.transform.localPosition = OriginalPosition;

                    if (massShape == ColliderShape.Cube)
                    {
                        BoxCollider bc = _gameObject.AddComponent<BoxCollider>();
                        bc.size = new Vector3(massSize, massSize, massSize);
                        bc.center = Vector3.zero;
                        _collider = bc;
                    } else if (massShape == ColliderShape.Sphere)
                    {
                        SphereCollider sc = _gameObject.AddComponent<SphereCollider>();
                        sc.radius = massSize;
                        sc.center = Vector3.zero;
                    }
                    _rigidBody = _gameObject.AddComponent<Rigidbody>();
                    _rigidBody.useGravity = true;
                }

                public SoftVertice(Vector3 originalVertice, GameObject gameObjectParent, float massSize, ColliderShape massShape)
                {
                    OriginalPosition = originalVertice;
                    CurrentPosition = originalVertice;
                    _velocity = Vector3.zero;
                    _gameObjectParent = gameObjectParent;
                    _id = (uint)_gameObjectParent.transform.childCount;
                    _gameObject = new GameObject("mass_" + _id);

                    CreateVerticeObject(massSize, massShape);
                }

            }

            private bool _meshFound = false; // We can't start the script before getting a valid mesh.

            /// <summary>
            /// Get mesh, vertices and initialize script
            /// </summary>
            /// <returns>True if succeded or already done, false otherwise.</returns>
            private bool Init()
            {
                if (!_meshFound)
                {
                    GameObject massParent = new GameObject("masses");
                    MeshFilter meshFilter = this.GetComponent<MeshFilter>();

                    massParent.transform.SetParent(this.transform);
                    massParent.transform.localPosition = Vector3.zero;
                    if (!meshFilter)
                        return false;
                    _originalMesh = meshFilter.mesh;
                    
                    Vector3[] originalVertices = _originalMesh.vertices;
                    _verticesCount = originalVertices.Length;
                    _vertices = new SoftVertice[_verticesCount];
                    _currentVertices = new Vector3[_verticesCount];

                    for (int i = 0; i < _verticesCount; i++)
                    {
                        _vertices[i] = new SoftVertice(originalVertices[i], massParent, _massSize, _massShape);
                    }

                    _meshFound = true;
                }
                return true;
            }

            /// <summary>
            /// Use this method when the mesh has been changed or modified to reset the script.
            /// </summary>
            public void SetDirty(bool isDirty = true)
            {
                _meshFound = !isDirty;
            }

            /// <summary>
            /// Use this method to 
            /// </summary>
            private void UpdateSoftBody()
            {
                for (int i = 0; i < _verticesCount; i++)
                {
                    _vertices[i].Update(_stiffness);
                    _currentVertices[i] = _vertices[i].CurrentPosition;
                }
                _originalMesh.SetVertices(_currentVertices);
            }

            void Start()
            {
                if (!Init())
                {
                    Debug.LogException(new MissingComponentException("Component 'MeshFilter' not found, ensure this object has a mesh."));
                }
            }

            void Update()
            {
                Init();
            }

            private void FixedUpdate()
            {
                if (Init())
                {
                    UpdateSoftBody();
                }
            }

            private void OnCollisionEnter(Collision collision)
            {
                
            }

            private void OnDrawGizmosSelected()
            {
                if (_originalMesh == null)
                {
                    MeshFilter ms = GetComponent<MeshFilter>();
                    if (ms)
                        _originalMesh = ms.sharedMesh;
                }
                else
                {
                    for (int i = 0; i < _originalMesh.vertexCount; i++)
                    {
                        if (_massShape == ColliderShape.Cube)
                            Gizmos.DrawCube(transform.position + _originalMesh.vertices[i], new Vector3(_massSize, _massSize, _massSize));
                        else if (_massShape == ColliderShape.Sphere)
                            Gizmos.DrawSphere(transform.position + _originalMesh.vertices[i], _massSize);
                    }
                }
            }
        }
    }
}
