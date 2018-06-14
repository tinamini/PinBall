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

	/// <summary>
	/// 画面右側がタッチされているか
	/// </summary>
	private bool isRithtTouch = false;

	/// <summary>
	/// 画面左側がタッチされているか
	/// </summary>
	private bool isLeftTouch = false;
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
		//入力を確認
		CheckInput();
		// 左矢印キー押下：左フリッパーを動作させる
		if (Input.GetKeyDown(KeyCode.LeftArrow) || isLeftTouch && tag == "LeftFripperTag")
		{
			SetAngle(this.flickAngle);
		}
		// 右矢印キー押下：右フリッパーを動作させる
		if (Input.GetKeyDown(KeyCode.RightArrow) || isRithtTouch && tag == "RightFripperTag")
		{
			SetAngle(this.flickAngle);
		}

		// 矢印キー離上：フリッパーを元に戻す
		if (Input.GetKeyUp(KeyCode.LeftArrow) || !isLeftTouch && tag == "LeftFripperTag")
		{
			SetAngle(this.defaultAngle);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow) || !isRithtTouch && tag == "RightFripperTag")
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

	private void CheckInput()
	{
		if (Input.touchCount > 0)
		{
			foreach (var touch in Input.touches)
			{
				if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				{
					if (touch.position.x > Screen.width / 2)
					{
						isRithtTouch = true;
					}
					else
					{
						isLeftTouch = true;
					}
				}
				else
				{
					if (touch.position.x > Screen.width / 2)
					{
						isRithtTouch = false;
					}
					else
					{
						isLeftTouch = false;
					}
				}
			}
		}
	}
	#endregion
}
