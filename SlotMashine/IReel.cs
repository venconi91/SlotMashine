﻿namespace SlotMashine
{
  using System.Collections.Generic;

  public interface IReel
  {
    IEnumerable<IEnumerable<Symbol>> Spin();
  }
}
