using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ボールを制御する
/// </summary>
public class BallController : MonoBehaviour
{
	#region Field
	/// <summary>
	/// ボールが見える可能性のあるz軸の最大値
	/// </summary>
	private float ballVisiblePosZ = -6.5f;

	/// <summary>
	/// ゲームオーバー表示テキスト
	/// </summary>
	private GameObject gameoverText;
	#endregion

	#region Method
	/// <summary> 
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		// ゲームオーバーテキストオブジェクト取得
		this.gameoverText = GameObject.Find("GameOverText");
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		// ボールが画面外に出た場合
		if (this.transform.position.z < this.ballVisiblePosZ)
		{
			// GameOver を表示
			this.gameoverText.GetComponent<Text>().text = "Game Over";
		}
	}
	#endregion
}
