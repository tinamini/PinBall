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

	/// <summary>
	/// 得点
	/// </summary>
	private int score = 0;

	/// <summary>
	/// 得点テキスト
	/// </summary>
	private GameObject scoreText;

	/// <summary>
	/// 衝突物と得点のテーブル
	/// </summary>
	private Dictionary<string, int> scoreTable = new Dictionary<string, int>
	{
		{ "SmallCloudTag"	,	5	},
		{ "SmallStarTag"	,	10	},
		{ "LargeStarTag"	,	20	},
		{ "LargeCloudTag"	,	25	},
	};
	#endregion

	#region Method
	/// <summary> 
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		// ゲームオーバーテキストオブジェクト取得
		this.gameoverText = GameObject.Find("GameOverText");

		// 得点テキストオブジェクト取得
		this.scoreText = GameObject.Find("ScoreText");
		this.scoreText.GetComponent<Text>().text = "SCORE:" + score;
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

		// 点数更新
		this.scoreText.GetComponent<Text>().text = "SCORE:" + score;
	}

	/// <summary>
	/// 衝突時に呼ばれる関数
	/// </summary>
	/// <param name="collision">衝突物</param>
	private void OnCollisionEnter(Collision collision)
	{
		int addScore;
		scoreTable.TryGetValue(collision.gameObject.tag, out addScore);
		this.score += addScore;
	}
	#endregion
}
