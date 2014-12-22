/*Starstructor, the Starbound Toolet 
Copyright (C) 2013-2014 Chris Stamford
Contact: cstamford@gmail.com

Source file contributers:
 Chris Stamford     contact: cstamford@gmail.com
 Adam Heinermann    contact: aheinerm@gmail.com

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starstructor.StarboundTypes.Renderer
{
    /// <summary>
    /// This class is used to hold information about how to render a material, including all the rules of the material
    /// such as texture offsets/sizes and which part of it to render depending on surrounding blocks.
    /// </summary>
    public class RenderTemplate
    {
        public Dictionary<string, TextureInfo> pieces { get; set; }
        public Dictionary<string, Rule> rules { get; set; }
        // matches (wtf?)

        /// <summary>
        /// Retrieves the rule that matches the given string.
        /// </summary>
        /// <param name="str">Rule to obtain.</param>
        /// <returns>Rule that was found, or null if the string given does not have a rule.</returns>
        public Rule getRule(string str)
        {
            Rule result = null;
            rules.TryGetValue(str, out result);
            return result;
        }

        /// <summary>
        /// Retrieves the piece that matches the given string.
        /// </summary>
        /// <param name="str">Piece to obtain.</param>
        /// <returns>Piece that was found, or null if the string given does not have a piece.</returns>
        public TextureInfo getPiece(string str)
        {
            TextureInfo result = null;
            pieces.TryGetValue(str, out result);
            return result;
        }


    }
}
