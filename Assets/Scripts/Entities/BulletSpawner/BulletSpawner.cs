using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class BulletSpawner : MonoBehaviour
{
    private bool _canShoot = true;
    private int _weaponID, _weaponValue, _weaponDivision = 3; 
    //El ID se saca en base al value dividido el division

    Proyectile proyectilePrefab;
    private Pool<Proyectile> _pool;

    List<Weapon> _weaponList = new List<Weapon>();
    Weapon _currentWeapon;

    private void Start()
    {        
        //le doy una manera de crear que digo yo y 2 funciones de la bala
        _pool = new Pool<Proyectile>(Factory, Proyectile.TurnOn, Proyectile.TurnOff, 2, true); //Hacer un factory aparte
        WeaponAdd();
    }

    private void Awake()
    {
        proyectilePrefab = Resources.Load<Proyectile>("Proyectile");
    }

    #region Shooting Functions
    public void Shoot() //cambiar a private y mandar un event o un observer
    {
        if (_canShoot)
        {
            var p = _pool.SendFromPool();
            p = new ProyectileBuilder().SetSpeed(_currentWeapon.speed)
                                       .SetLifeTime(_currentWeapon.lifeTime)
                                       .SetSound(_currentWeapon.sound)
                                       .SetSprite(_currentWeapon.AskForPath())
                                       .SetInmortality(_currentWeapon.isInmortal)
                                       .SetCollision(_currentWeapon.canColl)
                                       .SetSizeBC(_currentWeapon.sizeBC)
                                       .SetSizeTrans(_currentWeapon.sizeTrans)
                                       .SetMoveType(_currentWeapon.moveID)
                                       .SetActivable(_currentWeapon.GenerateActivable())
                                       .SetSpawner(this)
                                       .Create(p);

            p.transform.position = this.transform.position;
            p.transform.rotation = this.transform.rotation;
            
            _canShoot = false;
            StartCoroutine(ShootCooldown());

            
        }
    }
    
    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(_currentWeapon.cooldown);
        _canShoot = true;
    }
    #endregion

    #region Pool Functions
    
    public Proyectile Factory()
    {
        return Instantiate(proyectilePrefab);
    }

    public void DestroyProyectile(Proyectile b)
    {
        _pool.ReturnToPool(b);
    }
    #endregion

    #region WeaponStuff
    void WeaponAdd()
    {
        _weaponList.Add(new WeaponAutomatic());
        _weaponList.Add(new WeaponLaser());
        _weaponList.Add(new WeaponSin());
        _weaponList.Add(new WeaponBomb());

        UpdateWeapon(0);
    }
    
    public void ChangeWeapon()
    {
        //WeaponDivision es la cantidad de int necesario para cambiar las armas, o el valor que "divide" las bounds de la armas
        if (_weaponValue < (_weaponList.Count) * _weaponDivision)
        {
            _weaponValue += 1;
        }
        else
        {
            _weaponValue = 0;
        }
        
        //Debug.Log(_weaponValue);
        
        if ((_weaponValue % _weaponDivision) == 0)
        {
           int weaponNumber = _weaponValue / _weaponDivision;

           if(weaponNumber < _weaponList.Count)
            UpdateWeapon(weaponNumber);
        }
    }

    void UpdateWeapon(int val)
    {
        _weaponID = val;
        _currentWeapon = _weaponList[_weaponID];
        EventManager.TriggerEvent(EventManager.EventsType.Event_HUD_Weapon, _weaponID);
        //Debug.Log("El tipo de weapon es " + _weaponID);
        //Debug.Log("value es de " + val);
    }
    #endregion
}
