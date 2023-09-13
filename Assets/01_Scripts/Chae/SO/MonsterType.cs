using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterInfo
{
    public string monsterName;
    public int hp;
    public int attackDamage;

    public float movementSpeed;

    public MonsterColor monsterColor;

    public MonsterInfo(string name, int hp, int attackDamage, float movementSpeed, MonsterColor color)
    {
        this.monsterName = name;
        this.hp = hp;
        this.attackDamage = attackDamage;
        this.movementSpeed = movementSpeed;
        this.monsterColor = color;
    }
}

[CreateAssetMenu (menuName = "SO/Monster/Monster")]
public class MonsterType : ScriptableObject
{
    private static MonsterType instance;

    public static MonsterType Instance
    {
        get
        {
            // �ν��Ͻ��� null�� ��� ��ũ���ͺ� ������Ʈ�� ã�� �Ҵ�
            if (instance == null)
            {
                instance = Resources.Load<MonsterType>("MonsterType");
            }
            return instance;
        }
    }

    public List<MonsterInfo> monstersList;

    public void AddMonster(MonsterInfo monsterInfo)
    {
        if (monstersList == null)
            monstersList = new List<MonsterInfo>();

        monstersList.Add(monsterInfo);
    }
}
