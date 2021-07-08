using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateScriptable/Tower")]
public class ScriptableTower : ScriptableObject
{
    [SerializeField] Sprite sprite;
    [SerializeField] float damage;
    [SerializeField] float fire_rate;
    [SerializeField] string tower_name;
    [SerializeField] float shooting_radius;
    [SerializeField] float placing_radius;
    [SerializeField] Sprite bullet;
    [SerializeField] AudioClip shooting_sound;
    [SerializeField] int cost;
    public int Cost
    {
        get
        {
            return cost;
        }
    }
    public Sprite BulletSprite
    {
        get
        {
            return bullet;
        }
    }
    public AudioClip ShootingSound
    {
        get
        {
            return shooting_sound;
        }
    }
    public string Name
    {
        get
        {
            return tower_name;
        }
    }
    public Sprite SpriteTower
    {
        get
        {
            return sprite;
        }
    }
    public float Damage
    {
        get
        {
            return damage;
        }
    }
    public float FireRate
    {
        get
        {
            return fire_rate;
        }
    }
    public float ShootingRadius
    {
        get
        {
            return shooting_radius;
        }
    }
    public float PlacingRadius
    {
        get
        {
            return placing_radius;
        }
    }
}
