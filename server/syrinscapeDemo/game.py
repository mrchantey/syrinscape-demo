
from django.conf.urls import url, include
from channels.generic.websocket import WebsocketConsumer
from rest_framework.response import Response
from rest_framework.decorators import api_view
import json
weapon_type = '0'
enemy_type = '0'

socketInstance = None


def handle_response():
	dataStr = json.dumps({
		"weaponType": weapon_type,
		"enemyType": enemy_type,
        })
	if(socketInstance != None):
		socketInstance.send(text_data=dataStr)
	return Response(dataStr)


@api_view(['GET'])
def weapon_req(request):
	global weapon_type
	type_param = request.query_params.get('type', None)
	if(type_param != None):
		weapon_type = type_param
	return handle_response()


@api_view(['GET'])
def enemy_req(request):
	global enemy_type
	type_param = request.query_params.get('type', None)
	if(type_param != None):
		enemy_type = type_param
	return handle_response()


# https://www.sitepoint.com/premium/books/django-channels-for-real-time-updates/read/1

class SocketConsumer(WebsocketConsumer):
	def connect(self):
		global socketInstance
		socketInstance = self
		self.accept()
		handle_response()

	def disconnect(self, close_code):
		pass

	def receive(self, text_data):
		print(text_data)
		self.send(text_data="ping received")
