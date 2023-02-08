# SMSService.SoftTech

[Published version](https://smsmessage.cfif31.ru/api/swagger/index.html "published url")

### /api/SmsMessage

#### GET
Get all messages with states
##### Parameters

| Name |  Description | Required | Schema |
| ---- |  ----------- | -------- | ------ |
| utcTime | Date from which to receive the information  | No | dateTime |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

#### POST
Send new message

##### Data

Message data

| Name |  Description | Min length | Max length | Required | Schema |
| ---- |  ----------- | -------- | -------- | -------- | ------ |
| MessageText | Text of message  | 5 | 2048 | Yes | string |
| Phone | Phone number  | 8 | 20 | Yes | string |
| SenderName | Sender name | 3 | 32  | No | string |
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |
| 400 | Bad request |

### /api/SmsMessage/{id}

#### GET
Get message by id
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ------ |
| id | path | id of message | Yes | long |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |
