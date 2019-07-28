using UnityEngine;
using System.Collections;

public class IceBlockDestroy : MonoBehaviour {

	//bool onBlock;
	Animator anim;
	public float waitAfterStepped;
	public float waitAfterDestroy;
	public IceBlockDestroy block;
	// Use this for initialization
	void Start () {
		block = gameObject.GetComponent<IceBlockDestroy>();
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!block.gameObject.activeSelf){

			waitAfterDestroy-=Time.deltaTime;
			//waitAfterStepped=4;
			if(waitAfterDestroy < 0){
				
				block.gameObject.SetActive(true);
				anim.SetBool ("isStepped", false);
				//waitAfterDestroy=4;
			}
		}
	}

	void OnCollisionStay2D(Collision2D other)
	{

		StartCoroutine(MyTimer());
		//if(WaitForSeconds < 0)
		//{
		//}
		
	}

	IEnumerator MyTimer() 
	{ 
		anim.SetBool ("isStepped", true);
		yield return new WaitForSeconds(4.1F); 
		block.gameObject.SetActive(false);

	}
		
	void OnTriggerEnter2D()
	{
		//onBlock = true;

	}

	void OnTriggerExit2D(){
		//onBlock = false;
	}
}
