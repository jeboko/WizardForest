using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public float speed = 1.0F;
	public int rock_count = 0;
	public int wood_count = 0;

	public Text countRock;
	public Text countWood;

	public GameObject baricate;
    public GameObject build_checker;

	private void OnTriggerStay(Collider col)
{
		if(Input.GetKey(KeyCode.Space))
		{
			if (col.gameObject.tag == "rock")
			{
				Destroy(col.gameObject);
				rock_count++;
			}
			else if (col.gameObject.tag == "wood")
			{
				Destroy(col.gameObject);
				wood_count++;
			}
		}
}	
	void Start()
	{
		
	}


	void Update()
	{
		// 재료 카운트 텍스트에 입력
		countRock.text = "바위 X " + rock_count;
		countWood.text = "목재 X " + wood_count;

		if (Input.GetKey(KeyCode.D))
			transform.Translate(Vector3.right * speed * Time.deltaTime);


		if (Input.GetKey(KeyCode.A))
			transform.Translate(Vector3.left * speed * Time.deltaTime);


		if (Input.GetKey(KeyCode.W))
			transform.Translate(Vector3.forward * speed * Time.deltaTime);


		if (Input.GetKey(KeyCode.S))
			transform.Translate(Vector3.back * speed * Time.deltaTime);

		if (Input.GetKeyDown(KeyCode.Q))
		{
            Instantiate(baricate, build_checker.transform.position, Quaternion.identity).transform.parent = build_checker.transform;
            
            rock_count--;
			wood_count--;
		}
	}
}
