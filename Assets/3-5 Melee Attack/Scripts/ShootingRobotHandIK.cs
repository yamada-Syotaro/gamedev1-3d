﻿using UnityEngine;

/// <summary>
/// 手の IK を制御する。
/// </summary>
[RequireComponent(typeof(Animator))]
public class ShootingRobotHandIK : MonoBehaviour
{
    /// <summary>右手のターゲット</summary>
    [SerializeField] Transform _rightTarget = default;
    /// <summary>左手のターゲット</summary>
    [SerializeField] Transform _leftTarget = default;
    /// <summary>右手の Position に対するウェイト</summary>
    [SerializeField, Range(0f, 1f)] float _rightPositionWeight = 0;
    /// <summary>右手の Rotation に対するウェイト</summary>
    [SerializeField, Range(0f, 1f)] float _rightRotationWeight = 0;
    /// <summary>左手の Position に対するウェイト</summary>
    [SerializeField, Range(0f, 1f)] float _leftPositionWeight = 0;
    /// <summary>左手の Rotation に対するウェイト</summary>
    [SerializeField, Range(0f, 1f)] float _leftRotationWeight = 0;
    Animator _anim = default;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void OnAnimatorIK(int layerIndex)
    {
        // 右手に対して IK を設定する
        if (_rightTarget)
        {
            _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, _rightPositionWeight);
            _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, _rightRotationWeight);
            _anim.SetIKPosition(AvatarIKGoal.RightHand, _rightTarget.position);
            _anim.SetIKRotation(AvatarIKGoal.RightHand, _rightTarget.rotation);
        }

        // 左手に対して IK を設定する
        if (_leftTarget)
        {
            _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, _leftPositionWeight);
            _anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, _leftRotationWeight);
            _anim.SetIKPosition(AvatarIKGoal.LeftHand, _leftTarget.position);
            _anim.SetIKRotation(AvatarIKGoal.LeftHand, _leftTarget.rotation);
        }
    }
}
