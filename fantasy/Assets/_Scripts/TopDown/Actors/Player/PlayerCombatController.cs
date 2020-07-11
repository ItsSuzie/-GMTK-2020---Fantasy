using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{



    // Debuff Variables
    private bool D_Pacifism = false;



    // Initiate Attack
    public void initiateAttack()
    {
        // If not pacifised, attack
        if (!D_Pacifism)
        {
            
        }
    }




    public bool debuffPacifist
    {
        set { D_Pacifism = value; }
    }
}
