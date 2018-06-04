using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 雲を制御する
/// </summary>
public class CloudController : MonoBehaviour
{
	#region Field
	/// <summary>
	/// 最小サイズ
	/// </summary>
	private float minimumSize = 1.0f;

	/// <summary>
	/// 拡大縮小スピード
	/// </summary>
	private float magSpeed = 10.0f;

	/// <summary>
	/// 拡大率
	/// </summary>
	private float magnification = 0.07f;
	#endregion

	#region Method
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{

	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		// 雲の拡大縮小
		this.transform.localScale = new Vector3(this.minimumSize + Mathf.Sin(Time.time * this.magSpeed) * this.magnification, this.transform.localScale.y, this.minimumSize + Mathf.Sin(Time.time * this.magSpeed) * this.magnification);
	}
	#endregion
}
