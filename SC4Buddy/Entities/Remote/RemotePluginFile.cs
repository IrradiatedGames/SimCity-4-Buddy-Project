﻿namespace NIHEI.SC4Buddy.Entities.Remote
{
    public partial class RemotePluginFile
    {
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((RemotePluginFile)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397)
                       ^ (Checksum != null ? Checksum.GetHashCode() : 0);
            }
        }

        private bool Equals(RemotePluginFile other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Checksum, other.Checksum);
        }
    }
}
