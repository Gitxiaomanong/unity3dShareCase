using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createEnemy : MonoBehaviour
{
	public GameObject createEmeny;

	private float x;
	private float z;
	private Vector3 pos;

	private float time;
	private float interval = 1f;
	private float count = 30;
	private float computeCount;


	void Update()
	{

		time += Time.deltaTime;

		if (time > interval)
		{
			if (computeCount < count)
			{
				do
				{
					x = Random.Range(50, -60);
					z = Random.Range(-56, 60);
					pos = new Vector3(x, 0, z);
				} while (!monitorFowrdTank(pos));

				CreateEnemyTankFu();

				time = 0;
			}
		}

	}

	private void CreateEnemyTankFu()
	{

		Instantiate(createEmeny, new Vector3(x, 0, z), Quaternion.identity);

		computeCount++;
	}

	//以半径为7.5的距离判断周围有没有坦克
	private bool monitorFowrdTank(Vector3 pos)
	{
		return !Physics.CheckSphere(pos, 15, ~(1 << 8));
	}

}
