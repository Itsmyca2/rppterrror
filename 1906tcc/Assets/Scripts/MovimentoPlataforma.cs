using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlataforma : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] private Transform moveDestination;
    
    private Vector2 posicaoInicial;

    private Vector2 _moveTarget;
    
    private Vector2 _currentMoveDirection;
    
    private bool _isReturning;

    private float _originalLocalScaleX;
    
    // Start is called before the first frame update
    void Start()
    {
        _moveTarget = moveDestination.localPosition;
        
        posicaoInicial = transform.position;
        _currentMoveDirection = (posicaoInicial + _moveTarget - (Vector2) transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        if (!_isReturning)
        {
            if (Vector2.Distance(transform.position, posicaoInicial + _moveTarget) < 1f)
            {
                _isReturning = true;
                _currentMoveDirection = (posicaoInicial - (Vector2) transform.position).normalized;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, posicaoInicial) < 1f)
            {
                _isReturning = false;
                _currentMoveDirection = (posicaoInicial + _moveTarget - (Vector2) transform.position).normalized;
            }
        }
        transform.position += (Vector3)_currentMoveDirection * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

    private void OnDrawGizmos()
    {
        
        Debug.DrawLine(transform.position, transform.position + moveDestination.localPosition, Color.red);
        
        
    }
}
