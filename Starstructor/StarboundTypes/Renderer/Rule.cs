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
    /// The Rule class describes a rule that is used in the matches section of the <see cref="RenderTemplate"/>.
    /// 
    /// This simply indicates a list of rule entries. When this rule is evaluated, then it is assumed that
    /// every <see cref="RuleEntry"/> in this list must be true.
    /// </summary>
    public class Rule
    {
        public List<RuleEntry> entries { get; set; }

    }
}
