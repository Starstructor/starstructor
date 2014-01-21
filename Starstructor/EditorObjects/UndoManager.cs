/*Starstructor, the Starbound Toolet 
Copyright (C) 2013-2014 Chris Stamford
Contact: cstamford@gmail.com

Source file contributers:
 Adam Heinermann    contact: aheinerm@gmail.com
 Chris Stamford     contact: cstamford@gmail.com

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

namespace Starstructor.EditorObjects
{
    public struct BrushChangeInfo
    {
        public EditorBrush m_brushBefore, m_brushAfter;
        public int m_x, m_y;
    }

    public class UndoManager
    {
        private readonly List<BrushChangeInfo> m_undoBuffer = new List<BrushChangeInfo>();
        private readonly EditorMapLayer m_mapLayer;
        private int m_undoIndex = 0;
        
        // Expected ctor
        public UndoManager(EditorMapLayer layer)
        {
            m_mapLayer = layer;
        }

        // Registers an action that changes the map layer.
        // @TODO: have a BrushChanged for groups of tiles for later development (selection, copy pasta, user-defined doodads, etc)
        public void RegisterAction(EditorBrush before, EditorBrush after, int x, int y)
        {
            m_undoBuffer.RemoveRange(m_undoIndex, m_undoBuffer.Count - m_undoIndex);    // Clear the redo buffer

            BrushChangeInfo info = new BrushChangeInfo();
            info.m_brushBefore = before;
            info.m_brushAfter = after;
            info.m_x = x;
            info.m_y = y;

            m_undoIndex++;
            m_undoBuffer.Add(info);
        }

        // Undoes the last command passed to this manager.
        // Returns the change information that took place, or null if no change took place.
        public BrushChangeInfo? Undo()
        {
            if ( !CanUndo() )
                return null;

            m_undoIndex--;
            BrushChangeInfo brushUndone = m_undoBuffer[m_undoIndex];    // we assume that m_undoIndex is within bounds

            m_mapLayer.SetBrushAt(brushUndone.m_brushBefore, brushUndone.m_x, brushUndone.m_y, true);
            return brushUndone;
        }

        // Redoes a command that was undone by this manager
        // Returns the change information that took place, or null if no change took place.
        public BrushChangeInfo? Redo()
        {
            if ( !CanRedo() )
                return null;

            BrushChangeInfo brushRedone = m_undoBuffer[m_undoIndex];    // we assume that m_undoIndex is within bounds
            m_undoIndex++;

            m_mapLayer.SetBrushAt(brushRedone.m_brushAfter, brushRedone.m_x, brushRedone.m_y, true);
            return brushRedone;
        }
        
        // Checks if an undo operation is available
        public bool CanUndo()
        {
            return m_undoIndex != 0;
        }

        // Checks if a redo operation is available
        public bool CanRedo()
        {
            return m_undoIndex != m_undoBuffer.Count;
        }

        // Erases the entire undo/redo buffer
        public void Reset()
        {
            m_undoBuffer.Clear();
            m_undoIndex = 0;
        }
    }
}
