using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

/// <summary>
/// Midgard character save load.
/// </summary>
public static class DSAEigenschaftenSerializer {

    private static string FILENAME = "dsaEigenschaften.gd";

    public static DSAEigenschaften dsaCharacter = new DSAEigenschaften();

    //it's static so we can call it from anywhere
    public static bool Save(DSAEigenschaften dsaCharacter) {
        bool successSerialize = true;
        successSerialize= SerializeFile ();
        return successSerialize;
    }   

    public static bool Load()
    {
        bool successDeserialize = true;
        successDeserialize = DeserializeFile();
        return successDeserialize;
    }

    private static bool DeserializeFile()
    {
        bool successDeserialize = true;
        if (File.Exists(FILENAME))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(FILENAME, FileMode.Open);
            try
            {
                dsaCharacter = (DSAEigenschaften)bf.Deserialize(file);

            }
            catch (SerializationException ex)
            {
                Debug.LogError("Deserialisierung fehl geschlagen: " + ex.Message);
                successDeserialize = false;
            }
            file.Close();
        }
        return successDeserialize;
    }

    private static bool SerializeFile ()
    {
        bool successSerialize = true;
        BinaryFormatter bf = new BinaryFormatter ();
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Open (FILENAME, FileMode.OpenOrCreate);
        //you can call it anything you want
        try {
            bf.Serialize (file, dsaCharacter);
        }
        catch (SerializationException ex) {
            Debug.LogError ("Serialisierung fehl geschlagen: " + ex.Message);
            successSerialize = false;
        }
        file.Close ();
        return successSerialize;
    }
}