﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item_carro_", menuName = "Laranjo/Inventario/Item de Carro")]
public class item_carro : ScriptableObject
{
    public int id, id_ordem;
    public string nome;
    public string descricao;
    public int preco;
    public PosicaoItemCarro posicao;
    public GameObject prefab;
    public Sprite imagem;
    public raridadeItemCarro raridade;


}

[CreateAssetMenu(fileName = "roda_", menuName = "Laranjo/Inventario/Item de Carro (Roda)")]
public class item_pneu : item_carro{
    public aroNumeros aro;

    public GameObject prefab_2;

    public enum aroNumeros{
        aro15 = 15,
        aro17 = 17,
        aro19 = 19,
        aro22 = 22
    }
}

[CreateAssetMenu(fileName = "carroceria_", menuName = "Laranjo/Inventario/Item de Carro (Carroceria)")]
public class item_carroceria : item_carro{
    public int id_chassi;

    //public PosicaoItemCarro posicao = PosicaoItemCarro.Carroceria;
}

    public enum PosicaoItemCarro
    {
        Chassi = 0,
        Roda,
        ArCapo,
        ArTeto,
        Carroceria,
        Aerofolio
    }
        public enum raridadeItemCarro
    {
        SemNivel = 0,
        Nivel1,
        Nivel2,
        Nivel3,
        Nivel4,
        Nivel5,
        Nivel6
    }