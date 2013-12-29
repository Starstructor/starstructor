using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using DungeonEditor.EditorObjects;

namespace DungeonEditor
{
    public struct BrushChangeInfo
    {
        public EditorBrush m_brushBefore, m_brushAfter;
        public int m_x, m_y;
    }

    public class UndoManager
    {
        private List<BrushChangeInfo> m_undoBuffer = new List<BrushChangeInfo>();
        private int m_undoIndex = 0;
        private EditorMapLayer m_mapLayer;
        
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
