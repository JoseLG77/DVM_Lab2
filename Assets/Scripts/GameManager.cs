using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;

    public TextMeshProUGUI textoTiempo;
    public TextMeshProUGUI textoVida;
    public int vidaMaxima = 10;

    int vidaActual;
    float tiempo;

    void Awake()
    {
        Instancia = this;
    }

    void Start()
    {
        vidaActual = vidaMaxima;
        tiempo = 0;
        ActualizarVidaUI();
    }

    void Update()
    {
        tiempo += Time.deltaTime;
        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);
        textoTiempo.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }

    public void RestarVida(int cantidad)
    {
        vidaActual -= cantidad;
        ActualizarVidaUI();

        if (vidaActual <= 0)
        {
            Perder();
        }
    }

    void ActualizarVidaUI()
    {
        textoVida.text = vidaActual.ToString();
    }

    void Perder()
    {
        PlayerPrefs.SetFloat("TiempoFinal", tiempo);
        SceneManager.LoadScene("Resultados");
    }
}
