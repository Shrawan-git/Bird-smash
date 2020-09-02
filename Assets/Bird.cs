using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 _initialPosition;
    private bool _birdWasLaunched;
    private float _timeSittingAround;
    private float maxDistance = 6f;

    [SerializeField]private float _launchPower = 500;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        _initialPosition = transform.position;
    }

    private void Update(){

        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        if (_birdWasLaunched && 
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
            {
                _timeSittingAround += Time.deltaTime;
            }
            //timer for resetting the bird

        if (transform.position.y > 10 ||
            transform.position.y < -10 ||
            transform.position.x > 10 ||
            transform.position.x < -10 ||
            _timeSittingAround > 3)
        { 
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        
    }

   private void OnMouseDown(){
       GetComponent<SpriteRenderer>().color = Color.red;
       GetComponent<LineRenderer>().enabled = true;
       //enable line renderer when we drag
   }

   private void OnMouseUp(){
       GetComponent<SpriteRenderer>().color = Color.white;

       Vector2 directionToInitialPosition = _initialPosition - transform.position;

       GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
       GetComponent<Rigidbody2D>().gravityScale = 1;
       _birdWasLaunched = true;

        GetComponent<LineRenderer>().enabled = false;
        //release line renderer when stop dragging
        SoundManagerScript.playSoundFly();
   }

   private void OnMouseDrag(){
       Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       

       float distance = Vector3.Distance(newPosition, _initialPosition);
       if(distance > maxDistance){
           Vector3 direction = (newPosition - _initialPosition).normalized;
           rb.position = _initialPosition + direction * maxDistance;
       }else{
        transform.position = new Vector3 (newPosition.x , newPosition.y); 
       }
   }
}
