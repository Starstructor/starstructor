using System.Windows.Forms;
using Starstructor.StarboundTypes;

namespace Starstructor.GUI
{
    public partial class AssetGalleryComponent : UserControl
    {
        private StarboundAsset m_asset;

        public  StarboundAsset Asset
        {
            get { return m_asset; }
            set
            {
                m_asset = value;

                if (m_asset != null)
                    AssetPreviewImage.Image = m_asset.Image ?? EditorHelpers.GetGeneratedRectangle(64, 64, 0, 0, 0, 255);
            }
        }

        public AssetGalleryComponent()
        {
            InitializeComponent();
        }
    }
}
