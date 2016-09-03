using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class WatsonFeedback : MonoBehaviour
{
	[SerializeField] private DatasetBuilder db;
	private Renderer rend;
	private int showFrame;
	void Start ()
	{
		db.AddedPositiveExample += OnPositive;
		db.AddedNegativeExample += OnNegative;
		rend = GetComponent<Renderer>();
		rend.enabled = false;
	}

	private void OnNegative()
	{
		rend.material.color = Color.red;
		StartCoroutine(Show());
	}

	private void OnPositive()
	{
		rend.material.color = Color.green;
		StartCoroutine(Show());
	}

	private IEnumerator Show()
	{
		var thisFrame = Time.frameCount;
		showFrame = thisFrame;
		rend.enabled = true;
		yield return new WaitForSeconds(1.5f);
		if (showFrame == thisFrame)
		{
			rend.enabled = false;
		}
	}

	void OnDestroy()
	{
		db.AddedPositiveExample -= OnPositive;
		db.AddedNegativeExample -= OnNegative;
	}
}
