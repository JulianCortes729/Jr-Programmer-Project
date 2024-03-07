using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{

    private ResourcePile m_CurrenPile;
    public float ProductivityMultiplier = 2;

    //BuildingInRange tiene el objetivo de administrar todo lo que ocurre cuando una unidad interactúa con un conjunto de recursos
    //La anotación «as ResourcePile» define la variable pile a m_Target solo si m_Target es un tipo ResourcePile. Si m_Target es 
    //una Base, estos tipos no coincidirán y el conjunto debe definirse a null. Es una forma eficiente de revisar si m_Target 
    //es un conjunto de recursos. Si es (pile != null), entonces m_CurrentPile se define a ese conjunto de recursos y su ProductionSpeed se duplica.
    protected override void BuildingInRange()
    {
        /*
        En el siguiente fotograma, el enunciado condicional if en la parte superior del método evitará que 
        este código se ejecute de nuevo, porque m_CurrentPile se definirá a un valor (el conjunto de recursos).
        */
        if(m_CurrenPile == null){
            ResourcePile pile = m_Target as ResourcePile;

            if(pile != null){
                m_CurrenPile = pile;
                m_CurrenPile.ProductionSpeed *= ProductivityMultiplier;
            }

        }
    }

    /*A continuación, verifica si la variable m_CurrentPile es null. De no ser así, 
    entonces divide m_currentPile.ProductionSpeed entre ProductivityMultiplier para 
    devolverla a su valor original y después definirla como nula. */
    void ResetProductivity(){
        if(m_CurrenPile != null){
            m_CurrenPile.ProductionSpeed /= ProductivityMultiplier;
            m_CurrenPile = null;
        }
    }

    /*La etiqueta base le indica al Script que ejecute el método original además del nuevo código en este método anular. */
    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }

}
