using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SplineWalkerMode
{
    Once,
    Loop,
    PingPong
}
public class SpineWalk : MonoBehaviour
{
	public BezierSpline spline;

	public int frequency;

	public bool lookForward;

	public Transform[] items;

	private void Awake()
	{
		if (frequency <= 0 || items == null || items.Length == 0)
		{
			return;
		}
		Debug.Log(Mathf.Clamp01(-0.1555f));
		float stepSize = 1f / (frequency * items.Length);
		Transform item = Instantiate(items[0]) as Transform;
		Vector3 position = spline.GetPoint(0.1f);
		item.transform.localPosition = position;
		item.transform.parent = transform;

		//for (int p = 0, f = 0; f < frequency; f++)
		//{
		//	for (int i = 0; i < items.Length; i++, p++)
		//	{
		//		Transform item = Instantiate(items[i]) as Transform;
		//		Vector3 position = spline.GetPoint(p * stepSize);
		//		item.transform.localPosition = position;
		//		if (lookForward)
		//		{
		//			item.transform.LookAt(position + spline.GetDirection(p * stepSize));
		//		}
		//		item.transform.parent = transform;
		//	}
		//}
	}
}
