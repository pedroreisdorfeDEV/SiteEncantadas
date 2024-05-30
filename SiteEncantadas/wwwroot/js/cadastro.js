// Importa a biblioteca
import libphonenumber from 'google-libphonenumber';

// Cria uma instância do objeto PhoneNumberUtil
var phoneUtil = libphonenumber.PhoneNumberUtil.getInstance();

// Formata o número de telefone com uma máscara
var phoneNumber = '15555555555';
var formattedPhoneNumber = phoneUtil.format(phoneUtil.parse(phoneNumber, 'BR'), libphonenumber.PhoneNumberFormat.NATIONAL);

