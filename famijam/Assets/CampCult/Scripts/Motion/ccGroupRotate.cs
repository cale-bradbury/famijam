﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ccCreateGroup))]
public class ccGroupRotate: MonoBehaviour {
	public Vector3 minRotation = Vector3.zero;
	public Vector3 maxRotation = Vector3.zero;

	public AnimationCurve rotation;
	public float phase;
	public float frequency = 1;

	ccCreateGroup group;

	// Use this for initialization
	void Start () {
		group = GetComponent<ccCreateGroup>();
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i<group.all.Count;i++){
			group.all[i].transform.localEulerAngles = Vector3.Lerp(minRotation,maxRotation,rotation.Evaluate((frequency*i/group.all.Count+phase)%1.0f));
		}
	}
}
