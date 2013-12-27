using DungeonEditor.EditorObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEditor.StarboundObjects.Ships
{
    public class ShipPart : EditorMapPart
    {
        public override void UpdateLayerImage()
        {
            this.UpdateLayerImage(m_partLayers);
        }

        public override void UpdateLayerImage(List<EditorMapLayer> layers)
        {
            Graphics gfx = Graphics.FromImage(GraphicsMap);
            StarboundShip parentShip = (StarboundShip)m_parent;

            gfx.Clear(SystemColors.ControlDark);

            if (parentShip.BackgroundOverlays != null)
            {
                // Draw background overlays
                foreach (ShipOverlay overlay in parentShip.BackgroundOverlays)
                {
                    float originX = overlay.Position[0] * Editor.DEFAULT_GRID_FACTOR;
                    // Translate to the bottom-left, then offset by provided value
                    float originY = (GraphicsMap.Height - overlay.Image.Height) - (overlay.Position[1] * Editor.DEFAULT_GRID_FACTOR);

                    gfx.DrawImage(overlay.Image,
                        originX,
                        originY,
                        overlay.Image.Width,
                        overlay.Image.Height);
                }
            }

            base.UpdateLayerImage(layers, false, false, true, true);

            if (parentShip.ForegroundOverlays != null)
            {
                // Draw foreground overlays
                foreach (ShipOverlay overlay in parentShip.ForegroundOverlays)
                {
                    float originX = overlay.Position[0] * Editor.DEFAULT_GRID_FACTOR;
                    // Translate to the bottom-left, then offset by provided value
                    float originY = (GraphicsMap.Height - overlay.Image.Height) - (overlay.Position[1] * Editor.DEFAULT_GRID_FACTOR);

                    gfx.DrawImage(overlay.Image, originX, originY, overlay.Image.Width, overlay.Image.Height);
                }
            }

            gfx.Dispose();
        }

        public override void UpdateLayerImageBetween(int xmin, int ymin, int xmax, int ymax)
        {
            this.UpdateLayerImageBetween(xmin, ymin, xmax, ymax, false, false, false, false);
        }

        public override void UpdateLayerImageBetween(int xmin, int ymin, int xmax, int ymax, bool noFront, bool noBack, bool noSpecial, bool noClear)
        {
            this.UpdateLayerImageBetween(m_partLayers, xmin, ymin, xmax, ymax, noFront, noBack, noSpecial, noClear);
        }

        public override void UpdateLayerImageBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax)
        {
            this.UpdateLayerImageBetween(layers, xmin, ymin, xmax, ymax, false, false, false, false);
        }

        public override void UpdateLayerImageBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax, bool noFront, bool noBack, bool noSpecial, bool noClear)
        {            
            base.UpdateLayerImageBetween(layers, xmin, ymin, xmax, ymax, noFront, noBack, noSpecial, noClear);
        }
    }
}
