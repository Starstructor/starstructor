/*Starstructor, the Starbound Toolet
Copyright (C) 2013-2014  Chris Stamford
Contact: cstamford@gmail.com

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
*/

using System.Collections.Generic;
using System.Drawing;
using DungeonEditor.EditorObjects;

namespace DungeonEditor.StarboundObjects.Ships
{
    public class ShipPart : EditorMapPart
    {
        public override void UpdateLayerImage()
        {
            UpdateLayerImage(m_partLayers);
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
                    float originX = overlay.Position[0]*Editor.DEFAULT_GRID_FACTOR;

                    // Translate to the bottom, then offset by provided value
                    float originY = (GraphicsMap.Height - overlay.Image.Height) -
                                    (overlay.Position[1]*Editor.DEFAULT_GRID_FACTOR);

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
                    float originX = overlay.Position[0]*Editor.DEFAULT_GRID_FACTOR;
                    // Translate to the bottom-left, then offset by provided value
                    float originY = (GraphicsMap.Height - overlay.Image.Height) -
                                    (overlay.Position[1]*Editor.DEFAULT_GRID_FACTOR);

                    gfx.DrawImage(overlay.Image, originX, originY, overlay.Image.Width, overlay.Image.Height);
                }
            }

            gfx.Dispose();
        }

        public override void UpdateLayerImageBetween(int xmin, int ymin, int xmax, int ymax)
        {
            UpdateLayerImageBetween(xmin, ymin, xmax, ymax, false, false, false, false);
        }

        public override void UpdateLayerImageBetween(int xmin, int ymin, int xmax, int ymax, bool noFront, bool noBack,
            bool noSpecial, bool noClear)
        {
            UpdateLayerImageBetween(m_partLayers, xmin, ymin, xmax, ymax, noFront, noBack, noSpecial, noClear);
        }

        public override void UpdateLayerImageBetween(List<EditorMapLayer> layers, int xmin, int ymin, int xmax, int ymax)
        {
            UpdateLayerImageBetween(layers, xmin, ymin, xmax, ymax, false, false, false, false);
        }
    }
}