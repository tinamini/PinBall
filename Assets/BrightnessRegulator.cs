using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 輝度を調整する
/// </summary>
public class BrightnessRegulator : MonoBehaviour
{
	#region Field
	/// <summary>
	/// マテリアル
	/// </summary>
	private Material myMaterial = null;

	/// <summary>
	/// ターゲットのデフォルト色
	/// </summary>
	private Color defaultColor = Color.white;

	/// <summary>
	/// 発光度最小値
	/// </summary>
	private float minEmission = 0.3f;

	/// <summary>
	/// 発光強度
	/// </summary>
	private float magEmission = 2.0f;

	/// <summary>
	/// 角度
	/// </summary>
	private float degree = 0;

	/// <summary>
	/// 発光速度
	/// </summary>
	private int speed = 10;
	#endregion

	#region Method
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		// タグによって光らせる色を変える
		if (tag == "SmallStarTag")
		{
			this.defaultColor = Color.white;
		}
		else if (tag == "LargeStarTag")
		{
			this.defaultColor = Color.yellow;
		}
		else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
		{
			this.defaultColor = Color.cyan;
		}

		// オブジェクトにアタッチしているマテリアル取得
		this.myMaterial = GetComponent<Renderer>().material;

		myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		if (this.degree >= 0)
		{
			// 発光強度の計算
			Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);
			// エミッションに色設定
			myMaterial.SetColor("_EmissionColor", emissionColor);
			this.degree -= this.speed;
		}
	}

	/// <summary>
	/// 衝突時に呼ばれる関数
	/// </summary>
	/// <param name="collision">衝突物</param>
	private void OnCollisionEnter(Collision collision)
	{
		this.degree = 180;
	}
	#endregion
}
