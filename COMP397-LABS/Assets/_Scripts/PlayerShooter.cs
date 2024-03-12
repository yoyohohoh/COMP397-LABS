using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private List<Transform> _projectileSpawns;
    [SerializeField] private float _projectileForce = 0f;
    [SerializeField] private COMP397LABS _inputs;
    [SerializeField] private Transform _currentProjectileSpawn;
    [SerializeField] private Button _shootProjectileBtn;
    [SerializeField] private Button _turnProjectileSpawnLeft;
    [SerializeField] private Button _turnProjectileSpawnRight;

    private int _index = 0;

    private void Awake()
    {
        _currentProjectileSpawn = _projectileSpawns[_index];
        _inputs = new COMP397LABS();
        _inputs.Player.Fire.performed += _ => ShootProjectile();
        _inputs.Player.Camera.performed += context => ChangeProjectileSpawn(context.ReadValue<float>());
        _shootProjectileBtn.onClick.AddListener(() => ShootProjectile());
        _turnProjectileSpawnLeft.onClick.AddListener(() => ChangeProjectileSpawn(-1));
        _turnProjectileSpawnRight.onClick.AddListener(() => ChangeProjectileSpawn(1));
    }

    private void OnEnable()
    {
        _inputs.Enable();
    }

    private void OnDisable()
    {
        _inputs.Disable();
    }

    private void ShootProjectile()
    {
        GameObject projectile = Instantiate(_projectilePrefab, _currentProjectileSpawn.transform.position, _currentProjectileSpawn.transform.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * _projectileForce, ForceMode.Impulse);
    }

    private void ChangeProjectileSpawn(float direction)
    {
        _index += (int)direction;
        if (_index < 0) _index = _projectileSpawns.Count - 1;
        if (_index > _projectileSpawns.Count - 1) _index = 0;
        _currentProjectileSpawn = _projectileSpawns[_index];
    }
}