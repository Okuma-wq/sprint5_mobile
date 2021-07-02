import jwtDecode from 'jwt-decode';
import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View, ImageBackground } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class ListaConsultas extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listaConsultas: [],
      role: ''
    }
  }

  options = {
    hour: 'numeric', minute: 'numeric'
  }

  buscarDadosStorage = async () => {
    try {
      const valorToken = await AsyncStorage.getItem('token')
      //console.warn(valorToken)

      if (valorToken !== null) {
        this.setState({ role: jwtDecode(valorToken).role })
      }

      //console.warn(this.state.role)

    }
    catch (error) {
      console.warn(error)
    }
  }

  buscarConsultas = async () => {
    try {
      const token = await AsyncStorage.getItem('token');

      let Url = '/consulta'

      if (this.state.role === '2') {
        Url = '/consulta/medico';
      }
      else if (this.state.role === '3') {
        Url = '/consulta/paciente'
      }

      //console.warn(token)

      const response = await api.get(Url, {
        headers: { 'Authorization': 'Bearer ' + token }
      });

      const dadosAPI = response.data;

      this.setState({ listaConsultas: dadosAPI })

      //console.warn(this.state.listaConsultas)
    }

    catch (error) {

    }
  }

  componentDidMount() {
    this.buscarDadosStorage();
    this.buscarConsultas();
  }

  render() {
    return (
      <>
        {this.state.role === '2' ?
          <ImageBackground
            source={require('../../assets/img/imagem.png')}
            style={StyleSheet.absoluteFillObject}
          >
            <View style={styles.overlay}>
              <View style={styles.main}>
                {/* {this.state.renderConsulta && <ConsultaSelecionada consultaSelecionada={this.state.consultaSelecionada}/>} */}
                <View style={styles.mainHeader}>
                  <View style={styles.mainHeaderRow}>
                    <Image
                      source={require('../../assets/img/calendar.png')}
                      style={styles.mainHeaderImg}
                    />
                    <Text style={styles.mainHeaderText}>{'Consultas'.toLocaleUpperCase()}</Text>
                  </View>
                  <View style={styles.mainHeaderLine} />
                </View>
                <View style={styles.mainBody}>
                  <FlatList
                    contentContainerStyle={styles.mainBodyContent}
                    data={this.state.listaConsultas}
                    keyExtractor={(item) => item.dataConsulta}
                    renderItem={this.renderizaItemMedico}
                  />
                </View>
              </View>
            </View>
          </ImageBackground> : ''}

        {this.state.role === '3' ?
          <ImageBackground
            source={require('../../assets/img/imagem.png')}
            style={StyleSheet.absoluteFillObject}
          >
            <View style={styles.overlay}>
              <View style={styles.main}>
                {/* {this.state.renderConsulta && <ConsultaSelecionada consultaSelecionada={this.state.consultaSelecionada} />} */}
                <View style={styles.mainHeader}>
                  <View style={styles.mainHeaderRow}>
                    <Image
                      source={require('../../assets/img/calendar.png')}
                      style={styles.mainHeaderImg}
                    />
                    <Text style={styles.mainHeaderText}>{'Consultas'.toLocaleUpperCase()}</Text>
                  </View>
                  <View style={styles.mainHeaderLine} />
                </View>
                <View style={styles.mainBody}>
                  <FlatList
                    contentContainerStyle={styles.mainBodyContent}
                    data={this.state.listaConsultas}
                    keyExtractor={item => item.dataConsulta}
                    renderItem={this.renderizaItemPaciente}
                  />
                </View>
              </View>
            </View>
          </ImageBackground> : ''}

          {this.state.role === '1'?
        <ImageBackground
        source={require('../../assets/img/imagem.png')}
        style={StyleSheet.absoluteFillObject}
      >
        <View style={styles.overlay}>
          <View style={styles.main}>
            <Text style={styles.aviso}>O aplicativo só acomoda contas de paciente e medico</Text>
          </View>
        </View>
      </ImageBackground>: ''}

      </>
    )

  }


  renderizaItemMedico = ({ item }) => (
    <View style={styles.flatItemRow}>
      <View style={styles.flatItemContainer}>
        <Text style={styles.flatItemTitulo}>{item.idPacienteNavigation.nomePaciente}</Text>
        <Text style={styles.flatItemInfo}>{new Intl.DateTimeFormat('pt-BR').format(new Date(item.dataConsulta)) + " as " + new Intl.DateTimeFormat('pt-BR', this.options).format(new Date(item.dataConsulta).getTime().toString())}</Text>
        <Text style={styles.flatItemInfo}>{item.idSituacaoNavigation.situacao}</Text>
      </View>
      <View >
        <Image
          source={require('../../assets/img/view.png')}
          style={styles.flatItemImgIcon}
        />
      </View>
    </View>

  );

  renderizaItemPaciente = ({ item }) => (
    <View style={styles.flatItemRow}>
      <View style={styles.flatItemContainer}>
        <Text style={styles.flatItemTitulo}>{item.idMedicoNavigation.idEspecialidadeNavigation.especialidade1}</Text>
        <Text style={styles.flatItemInfo}>{new Intl.DateTimeFormat('pt-BR').format(new Date(item.dataConsulta)) + " as " + new Intl.DateTimeFormat('pt-BR', this.options).format(new Date(item.dataConsulta).getTime().toString())}</Text>
        <Text style={styles.flatItemInfo}>{item.idSituacaoNavigation.situacao}</Text>
      </View>
      <View >
        <Image
          source={require('../../assets/img/view.png')}
          style={styles.flatItemImgIcon}
        />
      </View>
    </View>

  );


}

const styles = StyleSheet.create({

  overlay: {
    ...StyleSheet.absoluteFillObject,
    backgroundColor: 'rgba(41, 91, 172, 0.80)',
  },

  main: {
    flex: 1,
    // backgroundColor: '#F1F1F1',
    // alignItems: 'center',
    // justifyContent: 'center',
  },

  //Cabeçalho
  mainHeader: {
    flex: 1,
    marginTop: 30,
    justifyContent: 'center',
    alignItems: 'center',
    // backgroundColor: 'red'
  },

  mainHeaderRow: {
    flexDirection: 'row'
  },

  mainHeaderImg: {
    width: 22,
    height: 22,
    tintColor: '#fff',
    marginTop: -2
  },

  mainHeaderText: {
    fontSize: 16,
    letterSpacing: 5,
    color: '#fff'
  },

  mainHeaderLine: {
    width: 170,
    paddingTop: 10,
    borderBottomColor: '#fff',
    borderBottomWidth: 1
  },

  //Corpo
  aviso: {
    color: 'red',
    textTransform: 'uppercase'
  },

  mainBody: {
    flex: 4,
    marginBottom: 50
    // backgroundColor: 'blue'
  },

  mainBodyContent: {
    paddingTop: 30,
    paddingRight: 50,
    paddingLeft: 50
  },

  flatItemRow: {
    flexDirection: 'row',
    borderBottomWidth: 2,
    borderBottomColor: '#ccc',
    marginTop: 15
  },

  flatItemContainer: {
    flex: 1
  },

  flatItemTitulo: {
    fontSize: 16,
    color: '#fff'
  },

  flatItemInfo: {
    fontSize: 12,
    color: '#ccc',
    lineHeight: 20
  },

  flatItemImg: {
    justifyContent: 'center'
  },

  flatItemImgIcon: {
    width: 23,
    height: 23,
    tintColor: '#fff',
    marginTop: 17
  }
});
