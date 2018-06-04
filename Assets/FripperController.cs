using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// フリッパーを制御する
/// </summary>
public class FripperController : MonoBehaviour
{
	#region Field
	/// <summary>
	/// HingeJoint Component
	/// </summary>
	private HingeJoint myHingeJoint;

	/// <summary>
	/// 初期の傾き
	/// </summary>
	private float defaultAngle = 20;

	/// <summary>
	/// 弾いた時の傾き
	/// </summary>
	private float flickAngle = -20;
	#endregion

	#region Method
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		this.myHingeJoint = GetComponent<HingeJoint>();
		SetAngle(this.defaultAngle);
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		// 左矢印キー押下：左フリッパーを動作させる
		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
		{
			SetAngle(this.flickAngle);
		}
		// 右矢印キー押下：右フリッパーを動作させる
		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
		{
			SetAngle(this.flickAngle);
		}

		// 矢印キー離上：フリッパーを元に戻す
		if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
		{
			SetAngle(this.defaultAngle);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
		{
			SetAngle(this.defaultAngle);
		}
	}

	/// <summary>
	/// フリッパーの傾きを設定
	/// </summary>
	/// <param name="angle">傾き</param>
	public void SetAngle(float angle)
	{
		JointSpring jointSpring = this.myHingeJoint.spring;
		jointSpring.targetPosition = angle;
		this.myHingeJoint.spring = jointSpring;
	}
	#endregion
}
