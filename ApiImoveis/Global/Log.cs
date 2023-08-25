﻿using ApiImoveis.Controllers;
namespace ApiImoveis.Global
{
    public class Log
    {
             public static void Save(string msg)
        {
           ImoveisController a = new ImoveisController();

            //verifica se a pasta existe 
            if (!Directory.Exists(Config.folderPath))
            {
                Directory.CreateDirectory(Config.folderPath);
            }
            //verifica se o arquivo existe
            if (!File.Exists(Config.filePath))
            {

                File.Create(Config.filePath).Dispose();
            }
            //grava o log no arquivo
            File.AppendAllText(Config.filePath, DateTime.Now.ToString("dd/MM/yyy HH:mm:ss")
                + " - " + msg + Environment.NewLine);
        }
    }
}
