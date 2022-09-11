using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Identity : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    #region ObjectType
    [Range(0, 7)]
    public int objType;
    // 0 is for player
    // 1 is for slimey
    // 2 is for speedy
    // 3 is for tank
    // 4 is for boomer
    // 5 is for rangey
    // 6 is for summoner
    // 7 is for minion
    #endregion
    public virtual void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
        if(currentHealth <= 0)
        {
            switch(objType)
            {
                default:
                    Die(PoolObjectType.Player);
                    break;
                case 1:
                    Die(PoolObjectType.Slimey);
                    break;
                case 2:
                    Die(PoolObjectType.Speedy);
                    break;
                case 3:
                    Die(PoolObjectType.Tank);
                    break;
                case 4:
                    Die(PoolObjectType.Boomer);
                    break;
                case 5:
                    Die(PoolObjectType.Rangey);
                    break;
                case 6:
                    Die(PoolObjectType.Summomner);
                    break;
                case 7:
                    Die(PoolObjectType.Minion);
                    break;
            }
        }
    }
    public virtual void Die(PoolObjectType type)
    {
        ObjPoolManager.instance.CoolObject(gameObject, type);
    }
    
}
