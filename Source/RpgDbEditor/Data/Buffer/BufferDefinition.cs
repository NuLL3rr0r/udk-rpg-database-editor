using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgDatabaseParser.Data.Buffer
{
    /// <summary>
    /// Contains the properties of a single buff.
    /// </summary>
    public class BufferDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BufferDefinition"/> class.
        /// </summary>
        public BufferDefinition()
        {
            Damages = new List<BufferDamage>();
            Modifiers = new List<CharacterPropertyModifier>();
            SpecialEffects = new List<BufferSpecialEffect>();
        }


        /// <summary>
        /// Gets or sets the unique ID of the buff.
        /// </summary>
        public string Id
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the name of this buff.
        /// </summary>
        public string Name
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the description of this buff.
        /// </summary>
        public string Description
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the duration of this buffer in seconds.
        /// Zero means immediate and a negative value means infinite duration.
        /// </summary>
        public float Duration
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the stacking behavior of this buff.
        /// </summary>
        public BufferStakingBehaviorTypes StackingBehavior
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of damages this buff can cause.
        /// </summary>
        public List<BufferDamage> Damages
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of property modifiers for this buff.
        /// </summary>
        public List<CharacterPropertyModifier> Modifiers
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the list of special effects for this buff.
        /// </summary>
        public List<BufferSpecialEffect> SpecialEffects
        {
            get;
            set;
        }


        /// <summary>
        /// Verifies this instance.
        /// </summary>
        internal void Verify()
        {
            throw new NotImplementedException();
        }
    }
}
