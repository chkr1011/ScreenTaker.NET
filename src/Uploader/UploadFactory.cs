using System;

namespace Screentaker.Uploader
{
    public enum UploadType { Imageshack, DirectUpload, FtpUpload };

    /// <summary>
    /// Eine Factory, die Uploadobjekte erzeugt mit denen es möglich ist Dateien an bestimmte
    /// Server hochzuladen.
    /// 
    /// Als Schnittstelle wird das Interface Upload genutzt.
    /// </summary>
    public class UploadFactory
    {
        /// <summary>
        /// Singleton
        /// </summary>
        private static UploadFactory INSTANCE = new UploadFactory();
        
        /// <summary>
        /// Singleton
        /// </summary>
        public static UploadFactory GetInstance { get { return INSTANCE; } }
        
        /// <summary>
        /// Privat, da Singleton
        /// </summary>
        private UploadFactory() { }

        /// <summary>
        /// Erzeugt ein Uploadobjekt an Hand des übergebenen Typs.
        /// </summary>
        /// <param name="type">Der Typ des zu erzeugenden Uploadobjektes</param>
        /// <returns>Ein Uploadobjekt</returns>
        public Upload createUpload(UploadType type)
        {
            Upload upload = null;

            switch (type)
            {
                case UploadType.Imageshack:
                    upload = new ImageshackUpload();
                    break;
                case UploadType.DirectUpload:
                    upload = new DirectUpload();
                    break;
                case UploadType.FtpUpload:
                    upload = new FtpUpload();
                    break;
                default:
                    throw new InvalidOperationException("Uploadtyp nicht verfügbar");
            }

            return upload;
        }
    }
}
