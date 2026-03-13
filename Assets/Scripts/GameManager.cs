using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemySpawner spawner;
    public GunShooter gun;
    public GameObject startMenu;

    public void StartGame()
    {
        if (spawner) spawner.enabled = true;
        if (gun) gun.gameStarted = true;
        if (startMenu) startMenu.SetActive(false);

        Debug.Log("Game started!");
    }
}