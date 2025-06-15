import 'package:marketplace/src/store/model/address_model.dart';
import 'package:mobx/mobx.dart';

part 'store_details.g.dart';

class StoreDetails = _StoreDetails with _$StoreDetails;

abstract class _StoreDetails with Store {
  @observable
  String _postalCode = "";
  String get postalCode => _postalCode;

  @observable
  String _street = "";
  String get street => _street;

  @observable
  String _complement = "";
  String get complement => _complement;

  @observable
  String _unit = "";
  String get unit => _unit;

  @observable
  String _neighborhood = "";
  String get neighborhood => _neighborhood;

  @observable
  String _city = "";
  String get city => _city;

  @observable
  String _stateAbbreviation = "";
  String get stateAbbreviation => _stateAbbreviation;

  @observable
  String _state = "";
  String get state => _state;

  @observable
  String _region = "";
  String get region => _region;

  @observable
  String _ibgeCode = "";
  String get ibgeCode => _ibgeCode;

  @observable
  String _giaCode = "";
  String get giaCode => _giaCode;

  @observable
  String _areaCode = "";
  String get areaCode => _areaCode;

  @observable
  String _siafiCode = "";
  String get siafiCode => _siafiCode;

  @observable
  String _number = "";
  String get number => _number;

  @action
  addNumber(String value) => _number = value;

  @action
  addComplement(String value) => _number = value;

  @action
  addCep(String value) => _postalCode = value;

  @action
  addFields(AddressModel input) {
    _postalCode = input.postalCode;
    _street = input.street;
    _complement = input.complement;
    _unit = input.unit;
    _neighborhood = input.neighborhood;
    _city = input.city;
    _stateAbbreviation = input.stateAbbreviation;
    _state = input.state;
    _region = input.region;
    _ibgeCode = input.ibgeCode;
    _giaCode = input.giaCode;
    _areaCode = input.areaCode;
    _siafiCode = input.siafiCode;
  }

  @action
  AddressModel getAddressModel() => AddressModel(
        areaCode: _areaCode,
        city: _city,
        complement: _complement,
        giaCode: _giaCode,
        ibgeCode: _ibgeCode,
        neighborhood: _neighborhood,
        postalCode: _postalCode,
        region: _region,
        siafiCode: _siafiCode,
        state: _state,
        stateAbbreviation: _stateAbbreviation,
        street: _street,
        unit: _unit,
      );

  @action
  initialize() {
    _postalCode = "";
    _street = "";
    _complement = "";
    _unit = "";
    _neighborhood = "";
    _city = "";
    _stateAbbreviation = "";
    _state = "";
    _region = "";
    _ibgeCode = "";
    _giaCode = "";
    _areaCode = "";
    _siafiCode = "";
  }
}
