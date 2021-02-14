# from django.contrib import admin
# from django.urls import path

# urlpatterns = [
#	 path('admin/', admin.site.urls),
# ]

from rest_framework.response import Response
from rest_framework.decorators import api_view
from django.conf.urls import url, include

weapon_type = 'none'

@api_view(['GET', 'POST'])
def weapon_req(request):
	global weapon_type
	type_param = request.query_params.get('type', None)
	if(type_param != None):
		weapon_type = type_param
	# return Response({"message": type_param == None})
	return Response({"weaponType": weapon_type})


urlpatterns = [
	url(r'^weapon$', weapon_req),
]
