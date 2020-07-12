using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNameSetter : MonoBehaviour
{
    public List<string> namesForEnemies;
    private Stack<string> enemyNames;
    private Stack<string> enemyNamesRefill;

    private void Awake()
    {
        enemyNames = new Stack<string>();
        enemyNamesRefill = new Stack<string>();

        // Randomize enemy names list
        Shuffle(namesForEnemies);

        // Fill the enemynames stack with names
        for(int i = 0; i < namesForEnemies.Count; i++)
        {
            enemyNames.Push(namesForEnemies[i]);
        }
    }


    // Modified from https://forum.unity.com/threads/clever-way-to-shuffle-a-list-t-in-one-line-of-c-code.241052/
    public static void Shuffle(List<string> ts) 
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i) {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }  

    public string getNameForObject()
    {
        // If the enemynames stack is empty, refill the stack with the refill stack
            if(enemyNames.Count == 0)
            {
                for (int j = 0; j < enemyNamesRefill.Count; j++)
                {
                    // Get top most from refil, push it onto enemynames
                    enemyNames.Push(enemyNamesRefill.Peek());

                    // pop one off refill
                    enemyNamesRefill.Pop();
                }
            }

                // Change object name
                string newName = enemyNames.Peek();
                enemyNamesRefill.Push(enemyNames.Peek());
                enemyNames.Pop();

        return newName;
    }

    //old name change - loop based
    // if (initiateNameChange)
        // {
        //     initiateNameChange = false;


        //     // change all object names
        //     for(int i = 0; i < EnemyHolder.childCount; i++)
        //     {
        //         Transform obj = EnemyHolder.GetChild(i);

        //         // If the enemynames stack is empty, refill the stack with the refill stack
        //         if(enemyNames.Count == 0)
        //         {
        //             for (int j = 0; j < enemyNamesRefill.Count; i++)
        //             {
        //                 // Get top most from refil, push it onto enemynames
        //                 enemyNames.Push(enemyNamesRefill.Peek());

        //                 // pop one off refill
        //                 enemyNamesRefill.Pop();
        //             }
        //         }

        //         // Change object name
        //         obj.name = enemyNames.Peek();
        //         enemyNamesRefill.Push(enemyNames.Peek());
        //         enemyNames.Pop();

        //         // obj.name = obj.name + "(" + i + ")";
        //         obj.GetComponent<Enemy>().createEnemyFile();
        //     }
        // }
        

}
