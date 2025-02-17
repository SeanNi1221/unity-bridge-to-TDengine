﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sean21.TDengineConnector;
[ExecuteInEditMode]
public class DataManager : MonoBehaviour
{
    public TH_Meter[] meterArray;
    public List<TH_Meter> meterList;
    public List<AlteredObject> alterTest;
    public AlterSTable alterSTest;
    void OnEnable()
    {
        // TDBridge.CreateSTable<TH_Meter>();
        // TDBridge.CreateTableUsing(meterList.ToArray());
        // TDBridge.CreateTableUsing(meterArray[0]);
        // TDBridge.Insert(meterList[0]);
        // TDBridge.CreateTable(alterTest[0]);
        // TDBridge.Insert(alterTest[0]);
        // TDBridge.InsertSpecific(alterTest[0]);
        // StartCoroutine(TDBridge.AlterTableOf(alterTest[0]));        
        // StartCoroutine(DropTables());
        // StartCoroutine(TDBridge.SetTags(meterList[0]));
        // TDBridge.SetTag(meterList[0],"name");
        // TDBridge.CreateSTable<AlterSTable>();
        // TDBridge.InsertSpecificUsing(meterList.ToArray());
        // TDBridge.InsertUsing(meterList.ToArray());
        // TDBridge.InsertUsing(meterList[0]);
        // StartCoroutine( TDBridge.AlterSTableOf<TH_Meter>() );
        // StartCoroutine(AddMeter());
        // StartCoroutine(AddPlainMeter());
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator AddMeter() {
        TDRequest r = new TDRequest("select * from test.th_meter limit 1");
        yield return r.Send();
        // TH_Meter t = gameObject.AddComponent<TH_Meter>();
        var t = gameObject.AddComponent<TH_Meter>();
        TDBridge.FromTD(ref t, r.result);
    }
    IEnumerator AddPlainMeter() {
        TDRequest r = new TDRequest("select * from test.th_meter limit 1");
        yield return r.Send();
        TH_Meter_Plain plainMeter = TDBridge.FromTD<TH_Meter_Plain>(r.result);
        Debug.Log(plainMeter.id + " " + plainMeter.name + " " + plainMeter.temperature);
    }
    IEnumerator DropTables() {
        for (int i=10; i<30; i++) {
            string tb_name = i.ToString();
            string drop = "DROP TABLE IF EXISTS " + "test.t" + tb_name;
            TDBridge.SendRequest(drop);
            yield return new WaitForEndOfFrame();
        }
    }

}
