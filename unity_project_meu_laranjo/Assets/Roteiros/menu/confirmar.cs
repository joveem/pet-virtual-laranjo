﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class confirmar : MonoBehaviour
{
    public GameObject menuConfirmacao, confirmado,excessoDeTentativas;
    UnityWebRequest link;
    public string site, id;
    public TMP_InputField conf_codigo;
    public Button conf_botao;
    public Image borda;
    public string[] resposta;
    public GameObject menu_ERRO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void botaoConfirma(){
        borda.color = new Color(1,0.5f,0);

        if(conf_codigo.text.Length == 6){
            StartCoroutine(fazerConfirmacao());
        }
        
    }

    IEnumerator fazerConfirmacao(){
        
        WWWForm form = new WWWForm();

        form.AddField("id", id);
        form.AddField("codigo", conf_codigo.text);

        link = UnityWebRequest.Post(gerenciador.host + site,form);

        conf_codigo.interactable = false;
        conf_botao.interactable = false;

        yield return link.SendWebRequest();

        if(link.isNetworkError || link.isHttpError){

            menu_ERRO.SetActive(true);

        }else
        {
            conf_codigo.interactable = true;
            conf_botao.interactable = true;

            resposta = link.downloadHandler.text.Split(',');

            if(resposta[0] == "1"){
                //registro confirmado
                
                
                confirmado.SetActive(true);

                gerDados.instancia.dados_.id = long.Parse(id);

                PlayerPrefs.SetInt("logado", 1);

                gerDados.instancia.baixarDados();

                Debug.Log("registro confirmado");

                gerDados.instancia.botao_logout.SetActive(true);

                menuConfirmacao.SetActive(false);
            }else
            {
                if(resposta[0] == "0"){
                    if(resposta[1] == "0"){
                        menuConfirmacao.SetActive(false);
                        excessoDeTentativas.SetActive(true);
                    }else
                    {
                        borda.color = new Color(1,0,0);
                    }
                }
                
            }
        }

        
        
        
    }
}
