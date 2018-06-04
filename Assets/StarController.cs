using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 星を制御する
/// </summary>
public class StarController : MonoBehaviour
{
	#region Field
	/// <summary>
	/// 回転速度
	/// </summary>
	private float rotSpeed = 1.0f;
	#endregion

	#region Method
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		// 回転開始の角度設定
		this.transform.Rotate(0, Random.Range(0, 360), 0);
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		this.transform.Rotate(0, this.rotSpeed, 0);
	}
	#endregion
}
