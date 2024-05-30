// Importa a biblioteca
import libphonenumber from 'google-libphonenumber';

// Cria uma inst�ncia do objeto PhoneNumberUtil
var phoneUtil = libphonenumber.PhoneNumberUtil.getInstance();

// Formata o n�mero de telefone com uma m�scara
var phoneNumber = '15555555555';
var formattedPhoneNumber = phoneUtil.format(phoneUtil.parse(phoneNumber, 'BR'), libphonenumber.PhoneNumberFormat.NATIONAL);

