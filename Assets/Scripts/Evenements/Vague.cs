using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vague : Evenement
{
    public int nbEnnemis;
    public List<GameObject> listEnnemis;
    public float interval;
    
    [Range(1,10)] public int nbSpawns;

    private List<Vector3> spawns;

    private void Awake()
    {
        spawns = new List<Vector3>();
        remplirSpawns();
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        StartCoroutine("Instancie");
    }

    // Update is called once per frame
    public override void Update()
    {
        if (FindObjectsOfType<Ennemi>().Length == 0)
        {
            objectifReussi = true;
        }
    }

    IEnumerator Instancie()
    {
        while (nbEnnemis != 0 && !objectifReussi)
        {
            int index = Random.Range(0, spawns.Count);
            Instantiate(listEnnemis[0], spawns[index], Quaternion.identity);
            yield return new WaitForSeconds(interval);
            nbEnnemis--;
        }
    }

    public void remplirSpawns()
    {
        float xmin = GameVariables.terrainXmin ;
        float xmax = GameVariables.terrainXmin + 10;
        float zmin = GameVariables.terrainZmin;
        float zmax = GameVariables.terrainZmax;
        
        float xmin1 = GameVariables.terrainXmax - 10;
        float xmax1= GameVariables.terrainXmax;
        float zmin1 = GameVariables.terrainZmin;
        float zmax1 = GameVariables.terrainZmax;
        
        float xmin2 = GameVariables.terrainXmin;
        float xmax2= GameVariables.terrainXmax;
        float zmin2 = GameVariables.terrainZmax - 10;
        float zmax2 = GameVariables.terrainZmax;
        
        float xmin3 = GameVariables.terrainXmin;
        float xmax3= GameVariables.terrainXmax;
        float zmin3 = GameVariables.terrainZmin;
        float zmax3 = GameVariables.terrainZmin + 10;


        for(int i = 0; i<nbSpawns; i++)
        {
            int choix = Random.Range(0, 3);
            if(choix == 0)
                spawns.Add(new Vector3(Random.Range(xmin, xmax), 0, Random.Range(zmin, zmax)));
            else if (choix == 1)
                spawns.Add(new Vector3(Random.Range(xmin1, xmax1), 0, Random.Range(zmin1, zmax1)));
            else if (choix == 2)
                spawns.Add(new Vector3(Random.Range(xmin2, xmax2), 0, Random.Range(zmin2, zmax2)));
            else if (choix == 3)
                spawns.Add(new Vector3(Random.Range(xmin3, xmax3), 0, Random.Range(zmin3, zmax3)));
        }
    }

    public override float getDuree()
    {
        duree = (interval * nbEnnemis) * 3;
        return duree;
    }
}