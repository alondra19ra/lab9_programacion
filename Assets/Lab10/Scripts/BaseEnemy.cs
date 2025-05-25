using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public int Life;
    public int Power;
    public GameObject target;

    public SeekPlayer agent;
    public void Set(int _life, int _power, GameObject target)
    {
        Life = _life;
        Power = _power;
        agent.target = target.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<BasePlayer>().TakeDamage();
            GameManager.Score += 10;
            Destroy(gameObject);
        }

    }
}
