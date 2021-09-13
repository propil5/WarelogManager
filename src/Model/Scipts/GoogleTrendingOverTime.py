from pytrends.request import TrendReq
import numpy as np
import sys

pytrends = TrendReq(hl='pl-PL', tz=360)
pytrends.build_payload(kw_list, cat=0, timeframe='today 12-m', geo='', gprop='')
print(pytrends.interest_over_time());
