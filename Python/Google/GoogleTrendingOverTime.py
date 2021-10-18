import numpy as np
import sys
from pytrends import TrendReq

pytrends = TrendReq(hl='pl-PL', tz=360)
pytrends.build_payload(kw_list, cat=0, timeframe='today 12-m', geo='', gprop='')
print(pytrends.interest_over_time());
