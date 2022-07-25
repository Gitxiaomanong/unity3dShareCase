using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
	private Transform Player;

	//地方坦克和玩家坦克的距离
	private float distance;
	private float lerpSpeed = 2;

	//反向向量
	private Vector3 direction;

	public GameObject bullet;
	private GameObject bulletObj;

	//移动和转身速度
	private float senSpeed = 10;
	private float moveSpeed = 10;

	//子弹和移动过程中随机旋转的时间间隔
	private float buttonTime;
	private float buttonTimer = 3;
	private float moveRotionTime;
	private float moveRotionTimer = 3;


	//射线

	RaycastHit hit;
	Ray ray;

	//子弹发射的位子
	public GameObject sendPostion;

	//声音
	public AudioClip clips;

	//保存随机旋转的变量
	int y;

	//保存坦克的位子信息
	private Vector3 currentPos;

	private AudioSource source;

	void Start()
	{
		Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
		source = GetComponent<AudioSource>();
	}

	void Update()
	{
		distance = Vector3.Distance(transform.position, Player.position);
		currentPos = transform.position;

		buttonTime += Time.deltaTime;
		moveRotionTime += Time.deltaTime;

		if (distance < 10)
		{
			//攻击
			Attack();
		}
		else if (distance < 25)
		{
			//向前移动
			move();
		}
		else
		{
			//巡逻
			cruiser();
		}

	}


	#region 转向玩家坦克

	private void rotationTo()
	{
		rotationPlayer();

	}

	private void rotationPlayer()
	{
		direction = Player.position - transform.position;

		rotationPlayerTank(direction);
	}

	private void rotationPlayerTank(Vector3 direction)
	{
		Quaternion qua = Quaternion.LookRotation(direction);

		rotation(qua);
	}

	private void rotation(Quaternion qua)
	{
		transform.rotation = Quaternion.Lerp(transform.rotation, qua, Time.deltaTime * lerpSpeed);
	}
	#endregion


	#region 判断地方坦克是不是队友
	bool monitorPlayerTabk(float dir)
	{
		ray = new Ray(sendPostion.transform.position, transform.forward);

		if (Physics.Raycast(ray, out hit, dir))
		{
			if (hit.collider.tag == "enemy")
			{
				return true;
			}
		}
		return false;
	}
	#endregion

	#region 判断
	private void cruiser()
	{
		Debug.Log("asd");
        ////判断左右连边是否有友方坦克
        if (TankCurrentPos(currentPos)) return;

        transform.position += transform.forward * moveSpeed * Time.deltaTime;

		if (moveRotionTime > moveRotionTimer)
		{
			y = Random.Range(0, 360);
			moveRotionTime = 0;
		}
		Quaternion qua = Quaternion.Euler(Vector3.up * y);
		rotation(qua);
	}


	private void move()
	{

		rotationTo();

		//判断左右连边是否有友方坦克
		//if (TankCurrentPos(currentPos)) return;

		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}


	private void Attack()
	{
		Debug.Log("asd");

		//rotationTo();

		//if (monitorPlayerTabk(150)) return;

		AttackFun();
	}
	#endregion

	#region 攻击函数
	void AttackFun()
	{
		if (buttonTime > buttonTimer)
		{
			//if (!AudioManage.Instace.source.isPlaying)
			//{
			//声音
			source.Play();

			bulletObj = Instantiate(bullet, sendPostion.transform.position, transform.rotation);

			bulletObj.GetComponent<Rigidbody>().velocity += transform.forward * senSpeed;

			Destroy(bulletObj, 2f);

			buttonTime = 0;
			//}
		}
	}

	#endregion
	//检测周围是否有友军
	bool TankCurrentPos(Vector3 pos)
	{
		return Physics.CheckSphere(pos, 50, ~(1 << 8));
	}

}
