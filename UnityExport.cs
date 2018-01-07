using System.Drawing.Imaging;
using System.IO;

namespace UnityExport
{
    public class UnityExport
    {
        public static void ExportTexture(AssetPreloadData asset, string exportPath)
        {
            var m_Texture2D = new Texture2D(asset, true);
            var bitmap = m_Texture2D.ConvertToBitmap(true);
            if (bitmap != null)
            {
                if (!exportPath.EndsWith("\\")) exportPath += "\\";
                bitmap.Save(exportPath + m_Texture2D.m_Name + ".png", ImageFormat.Png);
                bitmap.Dispose();
            }
            m_Texture2D = null;
        }

        public static void ExportAudioClip(AssetPreloadData asset, string exportPath)
        {
            if (!exportPath.EndsWith("\\")) exportPath += "\\";
            AudioClip m_AudioClip = new AudioClip(asset, true);            
            File.WriteAllBytes(exportPath + m_AudioClip.m_Name + ".mp3", m_AudioClip.m_AudioData);
            m_AudioClip = null;
        }

        public static void ExportText(AssetPreloadData asset, string exportPath)
        {
            if (!exportPath.EndsWith("\\")) exportPath += "\\";
            TextAsset TA = new TextAsset(asset, true);
            File.WriteAllBytes(exportPath + TA.m_Name + ".txt", TA.m_Script);
            TA = null;
        }

        public static void ExportMonoBehaviour(AssetPreloadData asset, string exportFilename)
        {
            if (!exportFilename.EndsWith(".txt")) exportFilename += ".txt";
            File.WriteAllText(exportFilename, new MonoBehaviour(asset, true).serializedText);
        }
    }
}
